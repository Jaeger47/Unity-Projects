using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Student
{
    public string name { get; set; }
    public int age { get; set; }
    public string email { get; set; }
    public bool isEnrolled { get; set; }
}

public class jsonDataClass
{
    public List<Student> students { get; set; }
}
