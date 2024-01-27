using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using CS408_PROJECT_DISUCORD_DAL;

namespace CS408_PROJECT_DISUCORD
{
    public partial class Form1 : Form
    {

        Socket serverSocket;
        List<User> allUsers; // A list of all users that are currently connected to the server successfully
        List<User> spsUsers; // A list of users that are connected (subscribed) to the sps101 channel
        List<User> ifUsers; // A list of users that are connected (subscribed) to the if100 channel
        bool isServerRunning;
        
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing); // Closing handler

            // Initating the variables
            allUsers = new List<User>();
            spsUsers = new List<User>();
            ifUsers = new List<User>();
            isServerRunning = false;
            


            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        // This function creates a socket hub on the port (written on the port textbox by user) 
        // It works with multithreads to handle multiple connections
        // If the port number is wrong it notifies the user
        private void startListening_Click(object sender, EventArgs e) 
        {
            int serverPort;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Initializing the socket 

            if (Int32.TryParse(portTextBox.Text, out serverPort)) // Checking if a legit port number is entered
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort); 
                serverSocket.Bind(endPoint); // Binding port with the socket 
                serverSocket.Listen(3); // Start listening on the given port for the connections

                isServerRunning = true;
                startListening.Enabled = false;
                stopListening.Enabled = true;

                Thread acceptThread = new Thread(Accept);  // Creating a new thread to listen connections 
                acceptThread.Start();

                activityTextBox.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                activityTextBox.AppendText("Please check port number \n");
            }
        }

        // This function listens for new connections
        private void Accept()
        {
            while (isServerRunning)
            {
                try
                {
                    Socket newClient = serverSocket.Accept(); // If a new user enters, accept and create a new connection(socket) for the client

                    Thread receivethread = new Thread(() => Receive(newClient)); // In order to have multiple connections, each client has its own threads
                    receivethread.Start();
                }
                catch
                {

                }
            }
        }

        // This function listens for client messages and manages them accordingly
        private void Receive(Socket thisClient) 
        {
            bool isConnected = true;

            while (isConnected) // While the connection is active
            {
                try
                {
                    // Read from the client via stream to get an object
                    NetworkStream stream = new NetworkStream(thisClient); 

                    BinaryFormatter formatter = new BinaryFormatter();

                    // Parsing the object as a DataMessage (properties can be found in DataMessage.cs)
                    DataMessage msg = formatter.Deserialize(stream) as DataMessage;

                    // Handling the message for the client
                    handleReceive(msg, thisClient);


                    // Stop listening form the stream until a new message arrives
                    stream.Close();

                }
                catch
                {
                    isConnected = false;
                }
            }
        }

        private void port_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // This function creates a new DataMessage object with given properties
        private DataMessage prepareMessage(string username, int channel, string message, int status)
        {
            DataMessage msg = new DataMessage();
            msg.Username = username;
            msg.ChannelId = channel;
            msg.Messaqe = message;
            msg.Status = status;

            return msg;
        }

        // This function send the DataMessage to the client
        private void SendMessage(string username, int channel, string message, int status, Socket conn)
        {
            try
            {
                DataMessage msg = prepareMessage(username, channel, message, status); // Creating a new DataMessage object

                using (var ms = new MemoryStream()) // Creating a stream to send that object byte by byte
                {
                    new BinaryFormatter().Serialize(ms, msg); // Serialize the object to send it byte by byte

                    IList<ArraySegment<byte>> data = new List<ArraySegment<byte>>();
                    data.Add(new ArraySegment<byte>(ms.ToArray()));

                    conn.Send(data); // Send the data to the client via the socket
                }
            } catch
            {
                activityTextBox.AppendText("There was a problem, please try again later");
            }
        }

        // This function handles the DataMessages - sent by client via a socket
        void handleReceive(DataMessage msg, Socket conn)
        {
            switch (msg.ChannelId) // Checking the channel id
            {
                case 0: // Server related actions - does not include sending message, user can only send messages to Sps or If if they are subscribed
                    if (msg.Status == 0) // If status is 0, a new client requested to connect to the socket
                        handleConnectServer(msg, conn);
                    else if (msg.Status == 1) // If status is 1, a client requested to disconnect from the server
                        handleDisconnectServer(msg, conn);

                    break;
                case 1: // SPS
                    if (msg.Status == 0) // If status is 0, a client requested to join Sps channel
                        handleJoinChannel(msg);
                    else if (msg.Status == 1)
                        handleLeaveChannel(msg); // If status is 1, a client requested to leave the Sps channel
                    else if (msg.Status == 2)
                        handleSendMessage(msg); // If status is 2, a client requested to send message to the Sps channel

                    break;
                case 2: // IF
                    if (msg.Status == 0)// If status is 0, a client requested to join If channel
                        handleJoinChannel(msg);
                    else if (msg.Status == 1)// If status is 1, a client requested to leave the If channel
                        handleLeaveChannel(msg);
                    else if (msg.Status == 2)// If status is 2, a client requested to send message to the If channel
                        handleSendMessage(msg);

                    break;
                default:
                    break;
            }
        }

        // This function connects a new client to the server
        void handleConnectServer(DataMessage msg, Socket conn)
        {
            if (allUsers.Any(u => u.Username == msg.Username)) // In case there is already a client with the same username
            {
                SendMessage(msg.Username, 0, "This username is already exist!", 1, conn);
                activityTextBox.AppendText(msg.Username + " is already exist in the server\n");
                conn.Close();
            }
            else
            {
                // Connecting the new client
                User newUser = new User();
                newUser.Username = msg.Username;
                newUser.Connection = conn;

                allUsers.Add(newUser); // Add the current user to the list of all connected users
                allUsersTextBox.AppendText(msg.Username + "\n");
                activityTextBox.AppendText(msg.Username + " is connected succesfully to the server\n");
                SendMessage(msg.Username, 0, "Connected succesfully", 0, conn);
            }
        }

        // This function disconnects the clients from the server
        void handleDisconnectServer(DataMessage msg, Socket conn)
        {
            var user = allUsers.FirstOrDefault(u => u.Username == msg.Username);
            if (user != null) // Checking if user is already in server
            {
                // Closing the connection and removing user from all lists
                activityTextBox.AppendText(msg.Username + " is disconnected from the server\n");
                SendMessage(msg.Username, 0, "Disconnected succesfully", 1, conn);
                conn.Close();
                allUsers.Remove(user);
                spsUsers.Remove(user);
                ifUsers.Remove(user);
            }
            allUsersTextBox.Text = string.Join("\n", allUsers.Select(u => u.Username)) + "\n";
            ifTextBox.Text = string.Join("\n", allUsers.Select(u => u.Username)) + "\n";
            spsTextBox.Text = string.Join("\n", allUsers.Select(u => u.Username)) + "\n";
        }

        // This function joins the client to the channel of their choice
        void handleJoinChannel(DataMessage msg)
        {
            var user = allUsers.FirstOrDefault(u => u.Username == msg.Username);
            if (msg.ChannelId == 1) // Channel id 1 is for Sps
            {
                spsUsers.Add(user); // add the user to the list of Sps clients
                SendMessage(msg.Username, 1, "Joined to SPS 101 Channel", 0, user.Connection);
                spsTextBox.AppendText(user.Username + "\n");
                activityTextBox.AppendText(user.Username + " is joined the SPS 101 Channel \n");
            }
            else if (msg.ChannelId == 2) // Channel id 2 is for If
            {
                ifUsers.Add(user); // add the user to the list of If clients
                SendMessage(msg.Username, 2, "Joined to IF 100 Channel", 0, user.Connection);
                ifTextBox.AppendText(user.Username + "\n");
                activityTextBox.AppendText(user.Username + " is joined the IF 100 Channel \n");
            }
        }

        // This function unsubscribes the user from the channel of their choice
        void handleLeaveChannel(DataMessage msg)
        {
            var user = allUsers.FirstOrDefault(u => u.Username == msg.Username);
            if (msg.ChannelId == 1) // Channel id 1 is for Sps
            {
                spsUsers.Remove(user); // Remove the user from list of Sps channel clients
                SendMessage(msg.Username, 1, "Left from SPS 101 Channel", 1, user.Connection);
                spsTextBox.Text = string.Join("\n", spsUsers.Select(u => u.Username));
                activityTextBox.AppendText(user.Username + " is left the SPS 101 Channel \n");
            }
            else if (msg.ChannelId == 2) // Channel id 2 is for If
            {
                ifUsers.Remove(user); // Remove the user from list of If channel clients
                SendMessage(msg.Username, 2, "Left from IF 100 Channel", 1, user.Connection);
                ifTextBox.Text = string.Join("\n", ifUsers.Select(u => u.Username));
                activityTextBox.AppendText(user.Username + " is left the IF 100 Channel \n");
            }
        }

        // This function broadcasts the messages sent by clients to a channel (Sps or If) of their choice
        void handleSendMessage(DataMessage msg)
        {
            
            activityTextBox.AppendText(msg.Username + " sent message ");
            if (msg.ChannelId == 1) // Channel id 1 is for Sps
            {
                activityTextBox.AppendText("to the SPS101 channel: " + msg.Messaqe + "\n");
                foreach (var user in spsUsers)
                {
                    SendMessage(msg.Username, 1, msg.Messaqe, 2, user.Connection);
                }
            }
            else if (msg.ChannelId == 2) // Channel id 2 is for If
            {
                activityTextBox.AppendText("to the IF100 channel: " + msg.Messaqe + "\n");
                foreach (var user in ifUsers)
                {
                    SendMessage(msg.Username, 2, msg.Messaqe, 2, user.Connection);
                }
            }
        }

        // This function stops the socket connection
        void handleStopListening()
        {
            foreach (var user in allUsers)
            {
                SendMessage(user.Username, 0, "The server has been stopped.", 1, user.Connection);
            }
            // Clear all users from the lists
            allUsers.Clear();
            spsUsers.Clear();
            ifUsers.Clear();
            isServerRunning = false; // Stop the server thread
            activityTextBox.AppendText("The server has been stopped.\n");
            allUsersTextBox.Clear();
            spsTextBox.Clear();
            ifTextBox.Clear();
            serverSocket.Close(); // Close the socket
            
           

        }

        // Stop listening
        private void stopListening_Click(object sender, EventArgs e)
        {
            handleStopListening();
            startListening.Enabled = true;
            stopListening.Enabled = false;
        }

        // Closing handlers
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (serverSocket != null)
            {
                handleStopListening();
            }
            Environment.Exit(0);
        }

    }
}