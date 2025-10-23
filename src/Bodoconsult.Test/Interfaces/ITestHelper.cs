//namespace Bodoconsult.Test.Interfaces
//{
//    /// <summary>
//    /// Interface for printing test output to different targets
//    /// </summary>
//    public interface ITestHelper
//    {
//        /// <summary>
//        /// Name of the company run the tests
//        /// </summary>
//        string Company { get; set; }

//        /// <summary>
//        /// Path to a logo image file (JPEG or PNG)
//        /// </summary>
//        string LogoPath { get; set; }

//        /// <summary>
//        /// Path to save the output (not used in TestHelperBase class)
//        /// </summary>
//        string TargetPath { get; set; }


//        /// <summary>
//        /// Work do be done before tests run
//        /// </summary>
//        void HelperInitialize();

//        /// <summary>
//        /// Final work to be done in the testhelper class
//        /// </summary>
//        void HelperFinalize();


//        /// <summary>
//        /// Print a message in the debug window and the output file
//        /// </summary>
//        /// <param name="inputString"></param>
//        /// <param name="array"></param>
//        void PrintIt(string inputString, params object[] array);

//        /// <summary>
//        /// Print a header for the output of unit testing
//        /// </summary>
//        void PrintHeader(string message);

//        /// <summary>
//        /// Print divider
//        /// </summary>
//        void PrintDivider();

//        /// <summary>
//        /// Print divider 1
//        /// </summary>
//        void PrintDivider1();

//        /// <summary>
//        /// Print divider
//        /// </summary>
//        void PrintShortDivider();

//        /// <summary>
//        /// Print an empty row
//        /// </summary>
//        void PrintRow();

//        /// <summary>
//        /// Print a message header level 1
//        /// </summary>
//        /// <param name="message">message to print</param>
//        /// <param name="typeName">name of the type</param>
//        /// <param name="methodName">name of the calling method</param>
//        void PrintMethodHeader(string message, string typeName, string methodName);

//        /// <summary>
//        /// Print a message header level 2
//        /// </summary>
//        /// <param name="message"></param>
//        void PrintMethodHeader2(string message);

//        /// <summary>
//        /// Print a message header level 3
//        /// </summary>
//        /// <param name="message"></param>
//        void PrintMethodHeader3(string message);


//        /// <summary>
//        /// Print a header for a class
//        /// </summary>
//        /// <param name="message">message to print</param>
//        /// <param name="className">class name</param>
//        void PrintClassHeader(string message, string className);

//        /// <summary>
//        /// Print a image to the output
//        /// </summary>
//        /// <param name="fileNameWithoutPath"></param>
//        void PrintImage(string fileNameWithoutPath);

//        /// <summary>
//        /// Print a table to the output
//        /// </summary>
//        /// <param name="data"></param>
//        void PrintTable(string[,] data);


//        /// <summary>
//        /// Get or set the current styling class (used only for HTML / CSS output)
//        /// </summary>
//        string CurrentClass { get; set; }

//        /// <summary>
//        /// Set formatting back to default
//        /// </summary>
//        void SetDefaults();


//        /// <summary>
//        /// Print a link to the default
//        /// </summary>
//        /// <param name="url"></param>
//        /// <param name="title"></param>
//        void PrintLink(string url, string title);

//    }
//}