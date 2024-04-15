using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace Movies
{
    public partial class Form1 : Form
    {

        //connection string 
        private readonly string connectionString = "Server=.;Database=movieassignment;Integrated Security=true;";
        private string[] _selectedFiles;
        private Label lblSelectedFiles;
        public Form1()
        {
            InitializeComponent();
            InitializeLabel(); // Initialize the label for displaying selected files
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Code that runs when the form is loaded
        }

        // Initialize the label for displaying selected files
        private void InitializeLabel()
        {
            lblSelectedFiles = new Label();
            lblSelectedFiles.Name = "lblSelectedFiles";
            lblSelectedFiles.Text = "Selected Files:";
            lblSelectedFiles.AutoSize = true;
           
            this.Controls.Add(lblSelectedFiles);
        }

        // Event handler for the "Select Files" button
        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Multiselect = true; // Allow multiple file selection

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedFiles = openFileDialog.FileNames;
                lblSelectedFiles.Text = string.Join("; ", _selectedFiles);  // Display selected file paths
            }
        }

        // Event handler for the "Insert Data" button
        private void btnInsertData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Loop through each selected file and insert its data into the database
                    foreach (string filePath in _selectedFiles)
                    {
                        string tableName = Path.GetFileNameWithoutExtension(filePath);  // Extract table name from file path
                        if (tableName.Equals("Movies"))
                            InsertMoviesData(connection, @"C:\Users\simus\Downloads\Data (1)\Movies.txt");  // Insert movies data
                        else if (tableName.Equals("Users"))
                            InsertUsersData(connection, @"C:\Users\simus\Downloads\Data (1)\Users.txt"); // Insert users data
                        else if (tableName.Equals("Ratings"))
                            InsertRatingsData(connection, @"C:\Users\simus\Downloads\Data (1)\Ratings.txt"); // Insert ratings data
                        else
                            MessageBox.Show($"Invalid file: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Data insertion completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to insert movies data into the database
        private void InsertMoviesData(SqlConnection connection,  string filePath)
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Iterate through each line starting from index 1 (excluding header)
            for (int i = 0; i < lines.Length; i++)
            {
                // Split the line into individual values based on the pipe (|) delimiter
                string[] values = lines[i].Split('|');

                // Construct the SQL INSERT query
                string insertQuery = "INSERT INTO Movies (MovieID, Title, ReleaseDate, IMDbLink, Action, Adventure, Comedy, Drama, Romance, Thriller, ScienceFiction, Animation, Fantasy, Horror, Musical, Mystery, Documentary, War, Crime, Western, FilmNoir, Childrens, Other) " +
                                     "VALUES (@MovieID, @Title, @ReleaseDate, @IMDbLink, @Action, @Adventure, @Comedy, @Drama, @Romance, @Thriller, @ScienceFiction, @Animation, @Fantasy, @Horror, @Musical, @Mystery, @Documentary, @War, @Crime, @Western, @FilmNoir, @Childrens, @Other)";

                // Create a SqlCommand object with the INSERT query and connection
                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Add parameters to the SqlCommand for each value
                command.Parameters.AddWithValue("@MovieID", values[0]);
                command.Parameters.AddWithValue("@Title", values[1]);
                command.Parameters.AddWithValue("@ReleaseDate", values[2]);
                command.Parameters.AddWithValue("@IMDbLink", values[4]);
                command.Parameters.AddWithValue("@Action", values[5]);
                command.Parameters.AddWithValue("@Adventure", values[6]);
                command.Parameters.AddWithValue("@Comedy", values[7]);
                command.Parameters.AddWithValue("@Drama", values[8]);
                command.Parameters.AddWithValue("@Romance", values[9]);
                command.Parameters.AddWithValue("@Thriller", values[10]);
                command.Parameters.AddWithValue("@ScienceFiction", values[11]);
                command.Parameters.AddWithValue("@Animation", values[12]);
                command.Parameters.AddWithValue("@Fantasy", values[13]);
                command.Parameters.AddWithValue("@Horror", values[14]);
                command.Parameters.AddWithValue("@Musical", values[15]);
                command.Parameters.AddWithValue("@Mystery", values[16]);
                command.Parameters.AddWithValue("@Documentary", values[17]);
                command.Parameters.AddWithValue("@War", values[18]);
                command.Parameters.AddWithValue("@Crime", values[19]);
                command.Parameters.AddWithValue("@Western", values[20]);
                command.Parameters.AddWithValue("@FilmNoir", values[21]);
                command.Parameters.AddWithValue("@Childrens", values[22]);
                command.Parameters.AddWithValue("@Other", values[23]);

                // Execute the INSERT command
                command.ExecuteNonQuery();
            }
        }

        // Method to insert ratings data into the database
        private void InsertRatingsData(SqlConnection connection, string filePath)
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('\t');
                //aligning datatype with the sql store data type
                DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                long unixTimestamp = long.Parse(parts[3]);
                DateTime timestamp = unixEpoch.AddSeconds(unixTimestamp);

                string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");

                string insertRatingQuery = "INSERT INTO Ratings (UserID, MovieID, Rating, Timestamp) " +
                                           $"VALUES ('{parts[0]}', '{parts[1]}', '{parts[2]}', '{formattedTimestamp}');";

                SqlCommand command = new SqlCommand(insertRatingQuery, connection);
                command.ExecuteNonQuery();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ratings.txt data successfully inserted.");
            Console.ResetColor();
        }

        // Method to insert users data into the database
        static void InsertUsersData(SqlConnection connection, string filePath)
        {
            //for loop 
            foreach (string line in File.ReadLines(filePath))
            {
                //spliting data
                string[] parts = line.Split('|');

                string insertUserQuery = "INSERT INTO Users (UserID, Age, Gender, Occupation, ZipCode) " +
                                        "VALUES (@UserID, @Age, @Gender, @Occupation, @ZipCode);";
                SqlCommand command = new SqlCommand(insertUserQuery, connection);
                command.Parameters.AddWithValue("@UserID", parts[0]);
                command.Parameters.AddWithValue("@Age", parts[1]);
                command.Parameters.AddWithValue("@Gender", parts[2]);
                command.Parameters.AddWithValue("@Occupation", parts[3]);
                command.Parameters.AddWithValue("@ZipCode", parts[4]);
                command.ExecuteNonQuery();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("users.txt data successfully inserted.");
            Console.ResetColor();
        }
   
    }
}
 