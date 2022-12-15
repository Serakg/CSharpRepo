using MindigFenyesUIModul;
using MindigFenyesConsoleModul_1;
using System.Windows.Controls;

namespace MindigFenyesTestModul
{
    public class UnitTest_Console1
    {
        [Fact]
        public void GetNapElteresTeszt()
        {
            Assert.Equal(9, MindigFenyesConsoleModul_1.Program.GetNapElteres(new DateTime(2022, 12, 10), new DateTime(2022, 12, 01)));
        }
    }
}