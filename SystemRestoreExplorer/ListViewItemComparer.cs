﻿using System;
using System.Collections;
using System.Windows.Forms;

namespace SystemRestoreExplorer
{
    public class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;

        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }

        public int Compare(object x, object y) 
        {
            int returnVal = -1;

            switch (col)
            {
                case 0:
                    returnVal = DateTime.Compare(
                        DateTime.Parse(((ListViewItem)x).SubItems[col].Text), 
                        DateTime.Parse(((ListViewItem)y).SubItems[col].Text));
                    break;

                default:
                    returnVal = String.Compare(
                        ((ListViewItem)x).SubItems[col].Text,
                        ((ListViewItem)y).SubItems[col].Text);
                    break;
            }

            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
            {
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            }

            return returnVal;
        }
    }
}