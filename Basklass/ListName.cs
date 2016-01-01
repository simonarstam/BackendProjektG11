using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Created by Simon Årstam, 2015-12-31.
/// </summary>
namespace ToDoList
{
    public class ListName
    {
        private int m_L_ID;
        private string m_L_Name;
        private string m_Errormsg;

        /// <summary>
        /// Getter and setter.
        /// Id of the ToDoList
        /// </summary>
        public int L_ID
        {
            get { return m_L_ID; }
            set { if (value >= 0) m_L_ID = value; }
        }

        /// <summary>
        /// Getter and setter.
        /// Name of the ToDoList.
        /// </summary>
        public string L_Name
        {
            get { return m_L_Name; }
            set { m_L_Name = value; }
        }

        /// <summary>
        /// Getter for Errormsg.
        /// </summary>
        public string Errormsg {
            get { return m_Errormsg; }
        }


        /// <summary>
        /// Checking values.
        /// </summary>
        /// <returns></returns>
        public bool checkData()
        {
            if (m_L_Name.Length < 6 || m_L_Name.Length > 25)
            {
                m_Errormsg = "Invalid length of name.";
                return false;
            }
                return true;
        }

    }
}
