using MindigFenyesUIModul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MindigFenyesTestModul
{
    public class UnitTest_UI
    {
        [StaFact]
        public void ListBoxItemsCheckTeszt()
        {
            ListBox testListBox= new ListBox();
            testListBox.Items.Add(1);
            Assert.True(MindigFenyesUIModul.MunkatarsWindow.CheckListBoxCountGreaterThanZero(testListBox));
        }
    }
}
