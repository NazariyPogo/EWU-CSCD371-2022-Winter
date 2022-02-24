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
    // 1.
    [TestMethod]
    public void Part1_FileWrittenToArray()
    {
        SampleData sampleData = new();

        Assert.IsTrue(sampleData.CsvRows.ElementAt(11) == "12,Vince,Dee,vdeeb@japanpost.jp,98027 Ridgeview Lane,Houston,TX,67224");
    }




    // 2.
    [TestMethod]
    public void Part2_TestingForSortUsingLINQ()
    {
        SampleData sampleData = new();
        List<string> list = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        Assert.AreEqual(0, list.LastIndexOf("AL"));
        Assert.AreEqual("WV", list.Last());
    }

    [TestMethod]
    public void Part2_TestingForSortUsingHardcodedList()
    {
        Assert.AreEqual(2, GetUniqueSortedListOfStatesGivenHardcodedList().Count());
        Assert.AreEqual("AL", GetUniqueSortedListOfStatesGivenHardcodedList().First());
        Assert.AreEqual("WA", GetUniqueSortedListOfStatesGivenHardcodedList().Last());  //Verifies AL moved to front
    }

    [TestMethod]
    public void Part2_TestingForUniquenessGivenCsvRows()
    {
        SampleData sampleData = new();

        Assert.AreEqual(sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList().IndexOf("WA"), 
            sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList().LastIndexOf("WA"));   //Only one is saved
    }

    public IEnumerable<string> GetUniqueSortedListOfStatesGivenHardcodedList()
     => GetListOfSpokaneAddresses() //Changed source of list but everything else stays the same
        .Select(row => row.Split(",")[6])
        .OrderBy(State => State)
        .Distinct();

    public IEnumerable<string> GetListOfSpokaneAddresses()
    {
        IEnumerable<string> list = new List<string>
        {
            "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022",
            "15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021",
            "19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021",
            "49,Arthur,Myles,amyles1c@miibeian.gov.cn,4718 Thackeray Pass,Mobile,AL,37308"
        };
        return list;
    }




    // 3.
    [TestMethod]
    public void Part3_TestingForUniqueness()
    {
        SampleData sampleData = new();
        List<string> stateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Split(",").ToList();

        Assert.AreEqual(22, stateList.IndexOf("TX"));
        Assert.AreEqual(22, stateList.LastIndexOf("TX"));   //TX 22nd state in list and only saved once
    }

    [TestMethod]
    public void Part3_TestingForSort()
    {
        SampleData sampleData = new();
        List<string> list = sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Split(",").ToList();

        Assert.AreEqual(0, list.LastIndexOf("AL"));
        Assert.AreEqual("WV", list.Last());
    }

    [TestMethod]
    public void Part3_FormattedProperly()
    {
        SampleData sampleData = new();
        string formatted = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

        Assert.AreEqual(formatted, sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
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
        return new List<Person>
        {
            new("Vince", "Dee", new Address("98027 Ridgeview Lane", "Houston", "TX", "67224"), "vdeeb@japanpost.jp"),
            new("Sancho", "Mahony", new Address("90 Birchwood Street", "Las Vegas", "NV", "36230"), "smahonyg@stanford.edu"),
            new("Marlow", "Gossart", new Address("711 Cambridge Court", "Pasadena", "TX", "73914"), "mgossarty@elpais.com"),
            new("Buck", "Aspin", new Address("286 Springs Circle", "Terre Haute", "IN", "72565"), "baspin1a@myspace.com"),
            new("Claudell", "Leathe", new Address("30262 Steensland Way", "Newport News", "VA", "87930"), "cleathe1d@columbia.edu"),
            new("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0 @state.gov"),
        };
    }

}
