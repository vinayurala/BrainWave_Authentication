using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;

namespace ScreenLock
{

    public enum UserType
    {
        Administrator,
        Limited
    };

    public enum ActivityType
    {
        Baseline,
        LetterTrace,
        Math,
        Graphical,
        Neutral
    };


    public class Activity
    {
        FeatureSet features = new FeatureSet();

       //   bool calculateFeatures() { return false; } This function should be written in matlab.
       
       


        // This feature set is not proper. Right now I don't know datatypes of that features.
        // So I am leaving them blank.

        public class FeatureSet     
        {
            double[] ar_coefficients;

            public double[] Ar_coefficients
            {
                get { return ar_coefficients; }
                set { ar_coefficients = value; }
            }
           
               
           // ar_coeff, power_spectral_entropy, non_linear_complexity, channel_spec_power, inter_hemispherical_channel_spectral_power

            double mean_approximate_entropy = 0.0;

            public double Mean_approximate_entropy
            {
                get { return mean_approximate_entropy; }
                set { mean_approximate_entropy = value; }
            }
           
            double mean_entropy = 0.0;

            public double Mean_entropy
            {
                get { return mean_entropy; }
                set { mean_entropy = value; }
            }

        }
    }



    public class Profile
    {

        public Profile(string userName)
        {
            this.userName = userName;

        }

        System.Collections.Generic.List<Activity> myActivityList = new System.Collections.Generic.List<Activity>();

        public System.Collections.Generic.List<Activity> MyActivityList
        {
            get { return myActivityList; }
            set { myActivityList = value; }
        }

        string userName;

        UserType profileUserType;

        public UserType ProfileUserType
        {
            get { return profileUserType; }
            set { profileUserType = value; }
        }


        bool encrypt() { return false; }

        public bool loadFromDisk(string userName) { return false; }

       // public static bool searchProfile(string userName) { return false; }

        public bool refineProfile(Profile newProfile) { return false; }

        public bool writeToDisk(string userName, System.Collections.Generic.List<Activity> activityList) { return false; }

    }

    public class Authentication
    {
        Emotiv.EmoEngine engine = null;
        string userName = null;
        Profile userProfile = null;

        public Authentication(string userName)
        {
            this.userName = userName;
            userProfile = new Profile(userName);
        }

       
        //bool searchProfile(string userName) { return false; }
        
        public bool startAuthentication() {

            if (ProfileManagement.searchProfile(userName))
            {
                if (userProfile.loadFromDisk(userName))
                {
                    foreach (Activity activity in userProfile.MyActivityList)
                    {
                        // write code to start testing the authentication.
                        // Connect to emotive headset and generate the .csv file.


                        // Now generate Matlab Object   

                        // Set global values of that matlab object.

                        // call calculateFeatureSet() function with respect to that object.

                        // now call match function in that matlab object.

                        // if the return value of match was true continue.

                        // else break and return false.

                        

                    }
                    // all cases were satisfied. So return true;

                    return true;
                }
            }
            
            return false; 
        
        }
    }


    public class ProfileManagement 
    {
        Profile newUserProfile = null;

        bool addNewProfile(string newUserName)
        {
            if (!searchProfile(newUserName))
            {
                newUserProfile = new Profile(newUserName);

                // Now start training ....

                // Connect to emotiv Engine. 
                // For each Activity types, show visual effects respectively.
                // Collect the brainwave information in .csv file.

                // Create matlab Object.

                // Calculate Feature set using matlab code.

                // write the feature details in a file.

                // Go to next Activity.   This is a loop.

                // If control exits from loop successfully, then return true;

                return true;
            }
            else
                return false;
        }

        bool deleteUserProfile(string userName)
        {
            if (new Authentication("admin").startAuthentication())
            {
                // Write code to delete the userName folder.
                // If delete operation was successful, return true;

                return true;
            }
            else
                return false;
        }

        public static bool searchProfile(string userName) { return false; }

    }

   

   
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BackgroundScreen());
            //Application.Run(new MainPromptForm());
        }
    }
}
