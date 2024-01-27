using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using CS408_PROJECT_DISUCORD_DAL;

namespace CS408_PROJECT_DISUCORD_CLIENT
{
    public partial class Form1 : Form
    {
        bool isConnected;
        Socket clientSocket;

        public Form1()
        {
            // Initializing the variables
            isConnected = false;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }


        private void connectButton_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = addressTextBox.Text;
            string port = portTextBox.Text;
            string username = usernameTextBox.Text;

            int portNum;
            if (Int32.TryParse(port, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum); // Connect to the socket by given port and ip numbers

                    isConnected = true;
                    Byte[] buffer = Encoding.Default.GetBytes(username);
                    SendMessage(0, null, 0); // Sending the message  to notify the server about connection of a new client

                    Thread receiveThread = new Thread(Receive); // Creating a new thread for receiving messages from the server
                    receiveThread.Start();

                }
                catch
                {
                    activityTextBox.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                activityTextBox.AppendText("Check the ports\n");
            }


        }

        // This function handles messages coming from the server
        private void Receive()
        {
            while (isConnected)
            {
                try
                {
                    // Read from the server via stream to get an object
                    NetworkStream stream = new NetworkStream(clientSocket);

                    BinaryFormatter formatter = new BinaryFormatter();

                    // Parsing the object as a DataMessage (properties can be found in DataMessage.cs)
                    DataMessage msg = formatter.Deserialize(stream) as DataMessage;

                    handleReceive(msg);

                    // Stop listening form the stream until a new message arrives
                    stream.Close();
                }
                catch // Checking whether anything is wrong with the object being sent
                {

                    clientSocket.Close();
                    isConnected = false;
                }

            }
        }

        // This function creates a new DataMessage object with given properties
        private DataMessage prepareMessage(int channel, string message, int status)
        {
            DataMessage msg = new DataMessage();
            msg.Username = usernameTextBox.Text;
            msg.ChannelId = channel;
            msg.Messaqe = message;
            msg.Status = status;

            return msg;
        }

        // This function send the DataMessage to the server
        private void SendMessage(int channel, string message, int status)
        {
            try
            {
                DataMessage msg = prepareMessage(channel, message, status); // Creating a new DataMessage object
                using (var ms = new MemoryStream()) // Creating a stream to send that object byte by byte
                {
                    new BinaryFormatter().Serialize(ms, msg); // Serialize the object to send it byte by byte

                    IList<ArraySegment<byte>> data = new List<ArraySegment<byte>>();
                    data.Add(new ArraySegment<byte>(ms.ToArray()));

                    clientSocket.Send(data); // Send the data to the client via the socket
                }
            }
            catch
            {
                activityTextBox.AppendText("There was a problem, please try again later");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            SendMessage(0, null, 1);
        }

        // This function handles the DataMessages - sent by server via a socket
        void handleReceive(DataMessage msg)
        {
            switch (msg.ChannelId) // Checking the channel id
            {
                case 0: // Server related actions - does not include sending message, user can only send messages to Sps or If if they are subscribed
                    if (msg.Status == 0)
                        handleConnect(msg); // If status is 0, this client wants to connect to the server
                    if (msg.Status == 1)
                        handleDisconnect(msg); // If status is 1, this client wants to disconnect from the server
                    break;
                case 1: // SPS
                    if (msg.Status == 0) // If status is 0, this client requested to join Sps channel
                        handleJoinChannel(msg);
                    else if (msg.Status == 1) // If status is 1, this client requested to disconnect from Sps channel
                        handleLeaveChannel(msg);
                    else if (msg.Status == 2) // If status is 2, this client wants to send message to the Sps channel
                        handleTakeMessage(msg);
                    break;
                case 2: // IF
                    if (msg.Status == 0) // If status is 0, this client requested to join If channel
                        handleJoinChannel(msg);
                    else if (msg.Status == 1) // If status is 1, this client requested to disconnect from Sps channel
                        handleLeaveChannel(msg);
                    else if (msg.Status == 2) // If status is 2, this client wants to send message to the Sps channel
                        handleTakeMessage(msg);
                    break;
            }
        }

        // This function makes necessary arrangements for the buttons when a client disconnects from server
        void handleDisconnect(DataMessage msg)
        {
            isConnected = false;
            activityTextBox.AppendText(msg.Messaqe + "\n");
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            spsConnectButton.Enabled = false;
            ifConnectButton.Enabled = false;
            spsDisconnectButton.Enabled = false;
            ifDisconnectButton.Enabled = false;
            spsMessageSendButton.Enabled = false;
            ifMessageSendButton.Enabled = false;
            spsMessageTextBox.Enabled = false;
            ifMessageTextBox.Enabled = false;
            clientSocket.Close();
        }

        // This function makes necessary arrangements for the buttons when a client connects to the server
        void handleConnect(DataMessage msg)
        {
            isConnected = true;
            activityTextBox.AppendText(msg.Messaqe + "\n");
            disconnectButton.Enabled = true;
            connectButton.Enabled = false;
            spsConnectButton.Enabled = true;
            ifConnectButton.Enabled = true;
        }

        // This function makes necessary arrangements for the buttons when a client connects to a channel
        void handleJoinChannel(DataMessage msg)
        {
            activityTextBox.AppendText(msg.Messaqe + "\n");
            if (msg.ChannelId == 1) // When client connects to the Sps channel
            {
                spsConnectButton.Enabled = false;
                spsDisconnectButton.Enabled = true;
                spsMessageTextBox.Enabled = true;
                if (!String.IsNullOrEmpty(spsMessageTextBox.Text))
                {
                    spsMessageSendButton.Enabled = true;
                }
            }
            else if (msg.ChannelId == 2) // When client connects to the If channel
            {
                ifConnectButton.Enabled = false;
                ifDisconnectButton.Enabled = true;
                ifMessageTextBox.Enabled = true;
                if (!String.IsNullOrEmpty(ifMessageTextBox.Text))
                {
                    ifMessageSendButton.Enabled = true;
                }
            }
        }

        // This function makes necessary arrangements for the buttons when a client disconnects from a channel
        void handleLeaveChannel(DataMessage msg)
        {
            activityTextBox.AppendText(msg.Messaqe + "\n");
            if (msg.ChannelId == 1) // When client disconnects from the Sps channel
            {
                spsConnectButton.Enabled = true;
                spsDisconnectButton.Enabled = false;
                spsMessageTextBox.Enabled = false;
                spsMessageSendButton.Enabled = false;
            }
            else if (msg.ChannelId == 2) // When client disconnects from the If channel
            {
                ifConnectButton.Enabled = true;
                ifDisconnectButton.Enabled = false;
                ifMessageTextBox.Enabled = false;
                ifMessageSendButton.Enabled = false;
            }
        }

        // This function makes necessary arrangements for the buttons when a client send messages to a channel
        void handleTakeMessage(DataMessage msg)
        {
            if (msg.ChannelId == 1) // When client sends a message to the Sps channel
            {
                spsTextBox.AppendText(msg.Username + ": " + msg.Messaqe + "\n");
            }
            else if (msg.ChannelId == 2) // When client sends a message to the If channel
            {
                ifTextBox.AppendText(msg.Username + ": " + msg.Messaqe + "\n");
            }
        }

        private void spsMessageSendButton_Click(object sender, EventArgs e)
        {
            SendMessage(1, spsMessageTextBox.Text, 2);
            spsMessageTextBox.Text = "";
        }

        private void ifMessageSendButton_Click(object sender, EventArgs e)
        {
            SendMessage(2, ifMessageTextBox.Text, 2);
            ifMessageTextBox.Text = "";
        }

        private void spsConnectButton_Click(object sender, EventArgs e)
        {
            SendMessage(1, null, 0);
        }

        private void ifConnectButton_Click(object sender, EventArgs e)
        {
            SendMessage(2, null, 0);
        }

        private void spsDisconnectButton_Click(object sender, EventArgs e)
        {
            SendMessage(1, null, 1);
        }

        private void ifDisconnectButton_Click(object sender, EventArgs e)
        {
            SendMessage(2, null, 1);
        }

        // This function is to ensure whether Sps send message button is correctly activated or deactivated for a given state
        private void spsMessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(spsMessageTextBox.Text))
            {
                spsMessageSendButton.Enabled = false;
            }
            else
            {
                spsMessageSendButton.Enabled = true;
            }
        }

        // This function is to ensure whether If send message button is correctly activated or deactivated for a given state
        private void ifMessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ifMessageTextBox.Text))
            {
                ifMessageSendButton.Enabled = false;
            }
            else
            {
                ifMessageSendButton.Enabled = true;
            }
        }

        // Closing handlers
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clientSocket != null)
            {
                SendMessage(0, null, 1);
            }
            Environment.Exit(0);
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}