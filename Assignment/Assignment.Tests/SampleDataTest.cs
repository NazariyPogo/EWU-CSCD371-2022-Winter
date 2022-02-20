using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

    [TestClass]
public class MyTestClass
{
    [TestMethod]
    public void AllParts_AllListsCreated()
    {
        SampleData sampleData = new();

        //Part1
        Assert.AreEqual(50, sampleData.CsvRows.Count());

        //Part2
        //TODO

        //Part3
        Assert.AreEqual(27, sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Split(",").Length);

        //Part4
        Assert.AreEqual(50, sampleData.People.Count());

        //Part5
        Assert.AreEqual(5, sampleData.FilterByEmailAddress(filter).Count());

        //Part6
        Assert.AreEqual(5, sampleData.GetAggregateListOfStatesGivenPeopleCollection(GetCollection()).Split(",").Count());
    }




    // 1.
    [TestMethod]
    public void Part1_FileWrittenToArray()
    {
        SampleData sampleData = new();

        Assert.IsTrue(sampleData.CsvRows.ElementAt(11) == "12,Vince,Dee,vdeeb@japanpost.jp,98027 Ridgeview Lane,Houston,TX,67224");
    }




    // 2.
    [TestMethod]
    public void Part2_TestingForSortUsingHardcodedList()
    {
        SampleData sampleData = new();


    }

    [TestMethod]
    public void Part2_TestingForSortUsingLINQ()
    {
        SampleData sampleData = new();


    }




    // 3.
    [TestMethod]
    public void Part3_()
    {
        SampleData sampleData = new();

        List<string> stateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Split(",").ToList();
        Assert.AreEqual(22, stateList.IndexOf("TX"));
        Assert.AreEqual(22, stateList.LastIndexOf("TX"));   //TX 22nd state in list and only saved once
    }




    // 4.
    [TestMethod]
    public void Part4_EachPersonHasAnAddress()
    {
        SampleData sampleData = new();

        Assert.AreEqual("4667 Jay Plaza", sampleData.People.Select(person => person.Address.StreetAddress).ElementAt(49));
    }

    [TestMethod]
    public void Part4_IsSortedByStateCityZip()
    {
        SampleData sampleData = new();

        Assert.AreEqual("Arthur", sampleData.People.First().FirstName);
        Assert.AreEqual("69152", sampleData.People.Select(person => person.Address.Zip).ElementAt(3));
    }




    // 5.
    [TestMethod]
    public void Part5_FilteredByEmailAddress_GoodValueIncluded()
    {
        SampleData sampleData = new();

        Assert.AreEqual(("Arthur", "Myles"), sampleData.FilterByEmailAddress(filter).First());  //CA
        Assert.AreEqual(("Amelia", "Toal"), sampleData.FilterByEmailAddress(filter).Last());    //WV
        Assert.IsTrue(sampleData.FilterByEmailAddress(filter).Any());
    }

    [TestMethod]
    public void Part5_FilteredByEmailAddress_BadValueExcluded()
    {
        SampleData sampleData = new();

        Assert.IsFalse(sampleData.FilterByEmailAddress(filter).Contains(("Vince", "Dee"))); //Id. 12
    }

    private bool filter(string obj) //Testing for  all .gov email addresses
    {
        return obj.Contains("gov");
    }




    // 6.
    [TestMethod]
    public void Part6_PropertyOnlyReturnsTheStatesWithinTheCollection()
    {
        List<string> stateList = GetList();

        Assert.IsTrue(stateList.Contains("TX"));
        Assert.IsFalse(stateList.Contains("WA"));
    }

    [TestMethod]
    public void Part6_StatesAreUnique()
    {
        List<string> stateList = GetList();

        Assert.AreEqual(stateList.IndexOf("TX"), stateList.LastIndexOf("TX"));  //Two TX in collection so one is not counted
    }

    public List<string> GetList()
    {
        SampleData sampleData = new();
        return sampleData.GetAggregateListOfStatesGivenPeopleCollection(GetCollection()).Split(",").ToList();
    }

    public List<Person> GetCollection()
    {
        List<Person> personCollection = new List<Person>
        {
            new("Vince", "Dee", new Address("98027 Ridgeview Lane", "Houston", "TX", "67224"), "vdeeb@japanpost.jp"),
            new("Sancho", "Mahony", new Address("90 Birchwood Street", "Las Vegas", "NV", "36230"), "smahonyg@stanford.edu"),
            new("Marlow", "Gossart", new Address("711 Cambridge Court", "Pasadena", "TX", "73914"), "mgossarty@elpais.com"),
            new("Buck", "Aspin", new Address("286 Springs Circle", "Terre Haute", "IN", "72565"), "baspin1a@myspace.com"),
            new("Claudell", "Leathe", new Address("30262 Steensland Way", "Newport News", "VA", "87930"), "cleathe1d@columbia.edu"),
            new("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0 @state.gov"),
        };
        return personCollection;
    }

}
