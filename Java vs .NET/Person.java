import java.net.*;
import java.io.*;
import java.util.*;

/**
 * This represents the data for one person.
 * @author trasa
 */
public class Person {
    
	private String firstName;
	private String lastName;
	private Date birthDate;
	private int children;
    
	
	/**
	 * Initializes a new instance of the Person class.
	 */
	public Person() {
	}

	/** 
	 * Initializes a new instance of the Person class.
	 *  
	 * @param children The number of children.
	 */
	public Person(int children) {
		this.children = children;
	}

	public String getFirstName() { 
		return firstName; 
	}
	
	public void setFirstName(String value) { 
		firstName = value; 
	}

	public String getLastName() { 
		return lastName; 
	}
	
	public void setLastName(String value) { 
		lastName = value; 
	}

	public Date getBirthDate() { 
		return birthDate; 
	}

	public void Date(DateTime value) { 
		birthDate = value; 
	}

	public int getChildren() { 
		return children; 
	}

	

	/**
	 * Computes the age of this person in years.
	 * 
	 * <p>Remarks: 
	 * aslkdfjlaskdjflkasjdflkasjdflkasdjflakf</p>
	 * 
	 * 
	 * 
	 *	@return the age in years.
	 */
	public int computeAge() {
		return (new Date().getYear()) - birthDate.getYear();
	}
}
