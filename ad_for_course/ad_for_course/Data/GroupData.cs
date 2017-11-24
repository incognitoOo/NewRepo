using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>

    {
        private string groupName;
        public string groupHeader = "";
        public string groupFooter = "";
        public GroupData (string groupName) { this.groupName = groupName; }
        public string GroupName     { get { return groupName; }     set { groupName = value; } }
        public string GroupHeader   { get { return groupHeader; }   set { groupHeader = value; } }
        public string GroupFooter   { get { return groupFooter; }   set { groupFooter = value; }
        }

        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, null))
            {
                return true;
            }
            return GroupName == other.GroupName;
        }
        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + GroupName;
        }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        }
    }
}