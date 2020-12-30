using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Kursach
{
	// static class for storing data
	// mechanism for accessing the data
	class ConfigUtils
	{
        #region Fields

        static ConfigData configData;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of seconds in a game
        /// </summary>
        public static int Greeting
        {
            get { return configData.Greeting; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes the configuration data by creating the ConfigurationData object 
        /// </summary>
        public static void Initialize()
        {
            configData = new ConfigData();
        }

        #endregion
    }
}
