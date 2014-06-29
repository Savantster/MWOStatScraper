/*
 *   MWOStatScraper is a tool to gather and process personal match data from 
 *   the MWOMercs website, for the game MechWarrior Online.
 * 
 *   Copyright (C) 2014  {Ray}
 *   
 *   See the full license notification in the frmMWOStatSys.cs file
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IntelligentStreaming.SharpTools;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWOStatSystem.Support_Classes
{
    class Parsers
    {
        // I (Ray) Pulled these parsers from the web.. I don't recall exactly where I got them, most
        // likely from comments in SourceForge or something. I'm pretty sure they are free to use since
        // I found them on the web. As I was not originally going to publish this application, I didn't
        // copy the link, but now that this is published, if anyone find this code on the web, please
        // update this comment with proper attribution and a link to the original.
        public DataTable ResultSetToDataTable( SqlCeResultSet set, ref Logger log )
        {
            try
            {

                DataTable dt = new DataTable();

                string stRow = "";
                // copy columns
                for ( int col = 0; col < set.FieldCount; col++ )
                {
                    stRow += set.GetName( col ) + "   " + set.GetFieldType( col ) + "   ";
                    dt.Columns.Add( set.GetName( col ), set.GetFieldType( col ) );
                }

                log.doIt( 3, stRow );
                // copy data
                while ( set.Read() )
                {
                    DataRow row = dt.NewRow();
                    stRow = "";
                    for ( int col = 0; col < set.FieldCount; col++ )
                    {
                        int ordinal = set.GetOrdinal( set.GetName( col ) );
                        row[col] = set.GetValue( ordinal );
                        stRow += row[col] + "   ";
                    }
                    log.doIt( 3, stRow );
                    dt.Rows.Add( row );
                }

                return dt;
            }
            catch ( Exception ex )
            {
                MessageBox.Show( "Error in parsing of data set: " + ex.Message );
            }
            return null;
        }

        // pulled from the web..
        public DataTable ReverseRowsInDataTable( DataTable inputTable )
        {
            DataTable outputTable = inputTable.Clone();

            for ( int i = inputTable.Rows.Count - 1; i >= 0; i-- )
            {
                outputTable.ImportRow( inputTable.Rows[i] );
            }

            return outputTable;
        }

        /// <summary>
        /// Parses out a table from HTML and puts it in a dataset..
        /// 
        /// Lifted from the internet, I forget from where.. but this wasn't me..
        /// 
        /// </summary>
        /// <param name="HTML">The HTML string to parse</param>
        /// <returns>DataSet contanining the tables</returns>
        public DataSet Convert( string HTML )
        {
            DataTable dt;
            DataSet ds = new DataSet();
            dt = new DataTable();
            string TableExpression = "<table[^>]*>(.*?)</table>";
            string HeaderExpression = "<th[^>]*>(.*?)</th>";
            string RowExpression = "<tr[^>]*>(.*?)</tr>";
            string ColumnExpression = "<td[^>]*>(.*?)</td>";
            bool HeadersExist = false;
            int iCurrentColumn = 0;
            int iCurrentRow = 0;

            MatchCollection Tables = Regex.Matches( HTML,
            TableExpression,
            RegexOptions.Singleline |
            RegexOptions.Multiline |
            RegexOptions.IgnoreCase );


            foreach ( Match Table in Tables )
            {
                iCurrentRow = 0;
                HeadersExist = false;
                dt = new DataTable();
                int iDupes = 0;

                if ( Table.Value.Contains( "<th" ) )
                {
                    HeadersExist = true;

                    MatchCollection Headers = Regex.Matches( Table.Value,
                    HeaderExpression,
                    RegexOptions.Singleline |
                    RegexOptions.Multiline |
                    RegexOptions.IgnoreCase );

                    foreach ( Match Header in Headers )
                    {
                        if ( dt.Columns.Contains( Header.Groups[1].ToString() ) )
                        {
                            dt.Columns.Add( Header.Groups[1].ToString() + iDupes++.ToString() );
                        }
                        else
                        {
                            dt.Columns.Add( Header.Groups[1].ToString() );
                        }
                        // dt.Columns.Add(iDupes++.ToString()); // generate generic headers to avoid other problems..
                    }

                }
                else
                {

                    int myvar2222 = Regex.Matches(
                    Regex.Matches(
                    Regex.Matches(
                    Table.Value,
                    TableExpression,
                    RegexOptions.Singleline
                    | RegexOptions.Multiline |
                    RegexOptions.IgnoreCase )[0].ToString(),
                    RowExpression, RegexOptions.Singleline |
                    RegexOptions.Multiline |
                    RegexOptions.IgnoreCase )[0].ToString(),
                    ColumnExpression,
                    RegexOptions.Singleline |
                    RegexOptions.Multiline |
                    RegexOptions.IgnoreCase ).Count;

                    for ( int iColumns = 1; iColumns <= myvar2222; iColumns++ )
                    {
                        dt.Columns.Add( "Column " + System.Convert.ToString( iColumns ) );
                    }

                }

                MatchCollection Rows = Regex.Matches( Table.Value,
                RowExpression,
                RegexOptions.Singleline |
                RegexOptions.Multiline | RegexOptions.IgnoreCase );

                foreach ( Match Row in Rows )
                {

                    if ( !( ( iCurrentRow == 0 ) & HeadersExist ) )
                    {
                        DataRow dr = dt.NewRow();
                        iCurrentColumn = 0;

                        MatchCollection Columns = Regex.Matches( Row.Value,
                        ColumnExpression,
                        RegexOptions.Singleline |
                        RegexOptions.Multiline |
                        RegexOptions.IgnoreCase );

                        foreach ( Match Column in Columns )
                        {
                            dr[iCurrentColumn] = Column.Groups[1].ToString();
                            iCurrentColumn++;
                        }

                        dt.Rows.Add( dr );
                    }
                    iCurrentRow++;
                }
                ds.Tables.Add( dt );

            }

            return ds;
        }

    }
}
