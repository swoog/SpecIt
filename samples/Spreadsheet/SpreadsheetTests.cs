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
            .And().Name_is_the_default_name();
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
            return then.Assert<SpreadSheet, IList<Sheet>>(s=> s.Sheets).HasSingle<Sheet, SheetThen>();
        }
    }

    public class SheetThen : ThenSteps<SheetThen>
    {
        public SheetThen(Scenario scenario)
            : base(scenario)
        {
        }

        public SheetThen Name_is_the_default_name()
        {
            return this;
            //return /*then*/.Assert<SpreadSheet, IList<Sheet>>(s => s.Sheets).HasSingle<Sheet>();
        }
    }

    public class Sheet
    {
    }

    public class SpreadSheet
    {
        public IList<Sheet> Sheets { get; set; }
    }

    public class SpreadsheetContext
    {
        public SpreadSheet SpreadSheet { get; set; }
    }
}
