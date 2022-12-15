using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindigFenyesConsoleModul_2;

namespace MindigFenyesTestModul
{
    public class UnitTest_Console2
    {
        [Fact]
        public void SzamKivonasTesztHelyes()
        {
            Assert.Equal(10, MindigFenyesConsoleModul_2.Program.SzamKivonas(20, 10));
        }

        [Fact]
        public void SzamKivonasTesztRossz()
        {
            Assert.False(MindigFenyesConsoleModul_2.Program.SzamKivonas(20, 10) == 5);
        }
    }
}
