using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spreadsheet
{
    using SpecIt;
    using SpecIt.Assert;

    using Xunit;

    public class SpreadsheetTests : Scenario
    {
        [Fact]
        public void a_spreadsheet_contains_a_sheet()
        {
            this
            .Given().a_spreadsheet()

            .Then().contains_a_sheet();
        }

        [Fact]
        public void a_spreadsheet_contains_a_sheet_with_a_default_name()
        {
            this
            .Given().a_spreadsheet()

            .Then().contains_a_sheet()
            .And().Name_is_the_default_name()
            .And().Description_is_null();
        }

        [Fact]
        public void Should_have_two_sheet_when_add_a_second_sheet()
        {
            this
            .Given().a_spreadsheet()
            .When().Add_sheet_named_sheetName("Sheet 2")
            .Then().contains_the_sheet_numberSheet(1)
            .And().Name_is_the_default_name()
            .And().Description_is_null()
            .And().contains_the_sheet_numberSheet(2)
            .And().Name_is_sheetName("Sheet 2")
            .And().Description_is_null();
        }
    }

    public static class SpreadsheetWhen
    {
        public static IWhenOperator Add_sheet_named_sheetName(this IWhen when, string sheetName)
        {
            return when.Action<SpreadSheet>(s => s.AddShhet(sheetName));
        }
    }


    public static class SpreadsheetGiven
    {
        public static IGivenOperator<IGiven> a_spreadsheet(this IGiven given)
        {
            given.Set(() => new SpreadSheet());
            return given.Next();
        }
    }

    public static class SpreadsheetThen
    {
        public static IThenOperator<SheetThen> contains_a_sheet(this IThen then)
        {
            return then.Assert<SpreadSheet, IList<Sheet>>(s => s.Sheets).HasSingle<Sheet, SheetThen>();
        }

        public static IThenOperator<SheetThen> contains_the_sheet_numberSheet(this IThen then, int numberSheet)
        {
            return then.Assert<SpreadSheet, IList<Sheet>>(s => s.Sheets).Has<Sheet, SheetThen>(numberSheet);
        }
    }

    public class SheetThen : ThenSteps<SheetThen>
    {
        public SheetThen(Scenario scenario)
            : base(scenario)
        {
        }

        public IThenOperator<SheetThen> Name_is_the_default_name()
        {
            return this.Name_is_sheetName("Sheet 1");
        }

        public IThenOperator<SheetThen> Name_is_sheetName(string sheetName)
        {
            this.Assert<Sheet, string>(s => s.Name).IsEqualTo(sheetName);
            return this.Next<SheetThen>();
        }

        public IThenOperator<SheetThen> Description_is_null()
        {
            this.Assert<Sheet, string>(s => s.Description).IsEqualTo(null);
            return this.Next<SheetThen>();
        }
    }

    public class Sheet
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class SpreadSheet
    {
        public SpreadSheet()
        {
            this.Sheets = new List<Sheet>();
            this.Sheets.Add(new Sheet() { Name = "Sheet 1" });
        }

        public IList<Sheet> Sheets { get; set; }

        public void AddShhet(string sheetName)
        {
            this.Sheets.Add(new Sheet() { Name = sheetName });
        }
    }

    public class SpreadsheetContext
    {
        public SpreadSheet SpreadSheet { get; set; }
    }
}
