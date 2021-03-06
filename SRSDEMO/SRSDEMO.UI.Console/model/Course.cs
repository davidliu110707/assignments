// Course.cs - Chapter 14 version.

// Copyright 2008 by Jacquie Barker  and Grant Palmer - all rights reserved.

// A MODEL class.

using System;
using System.Collections.Generic;

public class Course
{

    //----------------
    // Constructor(s).
    //----------------

    public Course(string cNo, string cName, double credits)
    {

        //  Initialize property values.

        CourseNumber = cNo;
        CourseName = cName;
        Credits = credits;

        // Create two empty Lists.

        OfferedAsSection = new List<Section>();
        Prerequisites = new List<Course>();
    }

    //-------------------------------
    // Auto-implemented properties.
    //-------------------------------

    public string CourseNumber { get; set; }
    public string CourseName { get; set; }
    public double Credits { get; set; }
    public List<Section> OfferedAsSection { get; set; }
    public List<Course> Prerequisites { get; set; }
    public static int SectionNumber { get; set; }//增加一个SectionNumber

     
    //-----------------------------
    // Miscellaneous other methods.
    //-----------------------------

    // Used for testing purposes.

    public void Display()
    {
        Console.WriteLine("Course Information:");
        Console.WriteLine("\tCourse No.:  " + CourseNumber);
        Console.WriteLine("\tCourse Name:  " + CourseName);
        Console.WriteLine("\tCredits:  " + Credits);
        Console.WriteLine("\tPrerequisite Courses:");

        // We use a foreach statement to step through the prerequisites.

        foreach (Course c in Prerequisites)
        {
            Console.WriteLine("\t\t" + c.ToString());
        }

        // Note use of Write vs. WriteLine in next line of code.

        Console.Write("\tOffered As Section(s):  ");
        for (int i = 0; i < OfferedAsSection.Count; i++)
        {
            Section s = (Section)OfferedAsSection[i];
            Console.Write(s.SectionNumber + " ");
        }

        // Print a blank line.
        Console.WriteLine("");
    }

    //**************************************
    //
    public override string ToString()
    {
        return CourseNumber + ":  " + CourseName;
    }

    //练习2  
    public void AddPrerequisite(Course c)
    {
        if (this == c)
        {
            Console.WriteLine("不能将自己设为先修课");

        }
        else
        {
            Prerequisites.Add(c);
        }

    }

    //**************************************
    //
    public bool HasPrerequisites()
    {
        if (Prerequisites.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

  

    public Section ScheduleSection(string day, string time, string room,
                         int capacity)
    {
        // Create a new Section (note the creative way in
        // which we are assigning a section number) ...
        
        //改正ScheduleStion的错误逻辑 
     Section s = new Section(SectionNumber + 1, day, time, this, room, capacity);  

        // ... and then add it to the List
            return s;
    } 
     //增加取消section的方法  
        public bool CancelSection(Section s)   {  
      
        
        this.OfferedAsSection.Remove(s);  
      
        return true;  

    
    
    }
    }
}}

  
      
    
   
