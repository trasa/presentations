using System;

namespace Dci.Core
{
    /// <summary>
    /// This represents the data for one person.
    /// </summary>
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private int children;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <remarks>
        /// these are my remarks
        /// <note type="warning">Warning! don't ever do this!</note>
        /// </remarks>
        /// <example><code>asldkfjasldkfjaslkdfja;</code></example>
        /// 
        public Person()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="children">The number of children.</param>
        public Person(int children)
        {
            this.children = children;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        
        /// <summary>
        /// Gets the number of children.
        /// </summary>
        /// <value>The number of children.</value>
        public int Children
        {
            get { return children; }
        }



        /// <summary>
        /// Computes the age of this person in years.
        /// </summary>
        /// <returns>The age in years.</returns>
        public int ComputeAge()
        {
            return DateTime.Now.Year - birthDate.Year;
        }
    }
}
