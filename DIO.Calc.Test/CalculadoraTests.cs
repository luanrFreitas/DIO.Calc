namespace DIO.Calc.Test
{
    public class CalculadoraTests
    {
        private Calculadora _calculadora;


        public CalculadoraTests()
        {
            _calculadora = new Calculadora(DateTime.Now);
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(17, 25, 42)]
        [InlineData(50, 182, 232)]

        public void Somar_DeveRetornarValorCorreto(int parcela1, int parcela2, int soma)
        {
            int resultado = _calculadora.Somar(parcela1, parcela2);
            Assert.Equal(soma, resultado);
        }

        [Theory]
        [InlineData(5, 3, 9)]
        [InlineData(17, 25, 43)]
        [InlineData(50, 182, 233)]
        public void Somar_DeveRetornarValorErrado(int parcela1, int parcela2, int soma)
        {
            int resultado = _calculadora.Somar(parcela1, parcela2);
            Assert.NotEqual(soma, resultado);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(17, 25, -8)]
        [InlineData(50, 182, -132)]
        public void Subtrair_DeveRetornarValorCorreto(int minuendo, int subtraendo, int diferenca)
        {
            int resultado = _calculadora.Subtrair(minuendo, subtraendo);
            Assert.Equal(diferenca, resultado);
        }

        [Theory]
        [InlineData(5, 3, 3)]
        [InlineData(17, 25, -9)]
        [InlineData(50, 182, -133)]
        public void Subtrair_DeveRetornarValorErrado(int minuendo, int subtraendo, int diferenca)
        {
            int resultado = _calculadora.Subtrair(minuendo, subtraendo);
            Assert.NotEqual(diferenca, resultado);
        }

        [Theory]
        [InlineData(5, 3, 15)]
        [InlineData(17, 25, 425)]
        [InlineData(50, 182, 9100)]
        public void Multiplicar_DeveRetornarValorCorreto(int fator1, int fator2, int produto)
        {
            int resultado = _calculadora.Multiplicar(fator1, fator2);
            Assert.Equal(produto, resultado);
        }

        [Theory]
        [InlineData(5, 3, 16)] 
        [InlineData(17, 25, 426)] 
        [InlineData(50, 182, 9101)] 
        public void Multiplicar_DeveRetornarValorErrado(int fator1, int fator2, int produto)
        {
            int resultado = _calculadora.Multiplicar(fator1, fator2);
            Assert.NotEqual(produto, resultado);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(10, 5, 2)]
        [InlineData(500, 20, 25)]
        public void Dividir_DeveRetornarValorCorreto(int dividendo, int divisor, int quociente)
        {
            int resultado = _calculadora.Dividir(dividendo, divisor);
            Assert.Equal(quociente, resultado);
        }

        [Theory]
        [InlineData(6, 3, 3)] 
        [InlineData(10, 5, 3)] 
        [InlineData(500, 20, 26)] 
        public void Dividir_DeveRetornarValorErrado(int dividendo, int divisor, int quociente)
        {
            int resultado = _calculadora.Dividir(dividendo, divisor);
            Assert.NotEqual(quociente, resultado);
        }

        [Fact]
        public void Dividir_DivisaoPorZero_DeveLancarDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(10, 0));
        }

        [Fact]
        public void Historico_DeveRetornarListaVazia()
        {
            _calculadora = new Calculadora(DateTime.Now);
            List<string> historico = _calculadora.Historico();
            Assert.Empty(historico);
        }

        [Fact]
        public void Historico_NaoDeveRetornarListaVazia()
        {
            _calculadora.Somar(1, 2);
            _calculadora.Somar(3, 5);
            _calculadora.Somar(5, 7);
            List<string> historico = _calculadora.Historico();
            Assert.NotEmpty(historico);
        }
    }
}