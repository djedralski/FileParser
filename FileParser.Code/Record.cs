using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileParser.Code
{
    /// <summary>
    /// Record Used for Person File/Api
    /// </summary>
    public class Record : IEquatable<Record>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Record(string lastName, string firstName, string gender, string favoriteColor, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }

        #region Equality

        public bool Equals(Record other)
        {
            if (other == null) return false;
            return string.Equals(LastName, other.LastName) &&
                string.Equals(FirstName, other.FirstName) &&
                string.Equals(Gender, other.Gender) &&
                string.Equals(FavoriteColor, other.FavoriteColor) &&
                DateOfBirth.Date == other.DateOfBirth.Date;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Record);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;

                hashCode = hashCode ^ LastName.GetHashCode() ^ FirstName.GetHashCode() ^ Gender.GetHashCode() ^ FavoriteColor.GetHashCode() ^ DateOfBirth.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
