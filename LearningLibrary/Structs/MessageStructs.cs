using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLibrary.Structs
{
    public struct TestStruct
    {
        // Propertys am besten weniger zugriefbar machen.
        private string _name;
        // und logisch einteilen!
        private string _surname;

        // Für Zugriffe von außen, am besten Getter/Setter Logik verwenden. 
        // Entsprechend ist die Logik sehr an C++ angelehnt.
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
    }    
}
