using System;

namespace Blackfin.Cms.Engine
{
    /// <summary>
    /// An object that pairs an attribute instance to the Type it was tagged against.
    /// </summary>
    /// <typeparam name="T">The <see cref="Attribute"/> we seek.</typeparam>
    public struct AttributeCatalogEntry<T> where T : Attribute
    {
        readonly T attr;
        readonly Type type;

        /// <summary>
        /// Create an instance of an AttributeCatalogEntry.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="type">The type.</param>
        public AttributeCatalogEntry(T attribute, Type type)
        {
            attr = attribute;
            this.type = type;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <value>The attribute.</value>
        public T Attribute { get { return attr; } }

        /// <summary>
        /// Gets the Type that this attribute was tagged against.
        /// </summary>
        /// <value>The type of the attribute target.</value>
        public Type AttributeTargetType { get { return type; } }

        #region Equality
        /// <summary>
        /// Compare two AttributeCatalogEntry objects for equality.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">the right hand side of the comparison.</param>
        /// <returns>True if the two objects are equal, otherwise false.</returns>
        public static bool operator ==(AttributeCatalogEntry<T> left, AttributeCatalogEntry<T> right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Compare two AttributeCatalogEntry objects for inequality.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">the right hand side of the comparison.</param>
        /// <returns>True if the two objects are not equal, otherwise false.</returns>
        public static bool operator !=(AttributeCatalogEntry<T> left, AttributeCatalogEntry<T> right)
        {
            return !Equals(left, right);
        }


        /// <summary>
        /// Test for equality between this instance and a given object.
        /// </summary>
        /// <param name="obj">Object to test against</param>
        /// <returns>True if this object is equal to obj</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            AttributeCatalogEntry<T> right = (AttributeCatalogEntry<T>)obj;

            return Equals(attr, right.attr) && Equals(type, right.type);
        }

        /// <summary>
        /// Get the HashCode for this AttributeCatalogEntry 
        /// </summary>
        /// <remarks>
        ///		<list type="number">
        ///			<item><description>
        ///				Two Objects that are Equal <b>MUST</b> generate the same HashCode.
        ///			</description></item>
        ///			<item><description>
        ///				An Object's HashCode <b>MUST</b> be Instance-Invariant 
        ///				(See below for definition of Instance Invariant)
        ///			</description></item>
        ///			<item><description>
        ///				For best performance, HashCode should be generated as a random distribution across all integers.
        ///			</description></item>
        ///		</list>
        ///		<br/>
        ///		<note type="caution">Breaking Rule 1 and 2 will break your class in creative and hard-to-debug ways!</note>
        ///		<br/>
        ///		<list type="definition">
        ///			<item>
        ///				<term><b>Instance Invariant</b></term>
        ///				<description>
        ///					A Value is Instance Invariant if it does not change over the entire life of the object 
        ///					(from Constructor through Finalizer) -- designated in C# by the "readonly" keyword.
        ///				</description>
        ///			</item>
        ///		</list>
        /// </remarks>
        ///	<example>
        /// Declaring an Instance Invariant value:
        ///		<code>
        ///			private readonly string someReadOnlyValue;
        ///
        ///			public AttributeCatalogEntry(string s) 
        ///			{
        ///				someReadOnlyValue = s; 
        ///			}
        /// 
        ///			public override int GetHashCode()
        ///			{
        ///				return s.GetHashCode();
        ///			}
        ///		</code>
        ///	</example>
        /// <returns>an integer obeying the rules for HashCode values.</returns>
        public override int GetHashCode()
        {
            return (attr == null ? 0 : attr.GetHashCode()) +
                   (type == null ? 0 : type.GetHashCode());
        }
        #endregion

    }
}
