using System;
using System.Collections.Generic;
using System.Reflection;

namespace DBLayer
{
    /// <summary>
    /// Describes DB object downloading
    /// </summary>
    public class MDBCObjectProperties
    {
        /// <summary>
        /// Describes which object must download
        /// </summary>
        private readonly Type _objectType;
        /// <summary>
        /// Describes which object fields must download
        /// </summary>
        private List<FieldInfo> _fields;

        /// <summary>
        /// Creates object, which must download
        /// </summary>
        /// <param name="objectType">Object type</param>
        public MDBCObjectProperties(string objectType)
        {
            _objectType = Type.GetType(objectType,true);
            _fields = new List<FieldInfo>();
            Filters = new Dictionary<string, object>();
            Dependences = new List<MDBCObjectProperties>();
        }
        /// <summary>
        /// Add object field, wich must download
        /// </summary>
        /// <param name="fieldName">Object field name</param>
        public void AddField(string fieldName)
        {
            FieldInfo field = _objectType.GetField(fieldName);
            if (field == null) throw new MissingFieldException(_objectType.Name, fieldName);
            _fields.Add(field);
        }
        /// <summary>
        /// Add filter, wich reduce selection
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddFilter(string key, object value)
        {
            if (Filters.ContainsKey(key))
                Filters[key] = value;
            else
                Filters.Add(key, value);
        }
        /// <summary>
        /// Get/Set filters, wich reduce selection
        /// </summary>
        public Dictionary<string, object> Filters { get; set; }
        /// <summary>
        /// Get/Set dependences, wich must download too
        /// </summary>
        public List<MDBCObjectProperties> Dependences { get; set; }
        /// <summary>
        /// Get object type, wich must download 
        /// </summary>
        public Type ObjectType
        {
            get
            {
                return _objectType;
            }
        }


    }
}
