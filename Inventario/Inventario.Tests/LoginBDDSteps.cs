using System;
using TechTalk.SpecFlow;

namespace Inventario.Tests
{
    [Binding]
    public class LoginBDDSteps
    {
        [Given(@"estoy en la pagina de inicio de sesion")]
        public void GivenEstoyEnLaPaginaDeInicioDeSesion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"complete el cuadro de texto con el codigo '(.*)'")]
        public void WhenCompleteElCuadroDeTextoConElCodigo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"complete el cuadro de texto del password con el valor '(.*)'")]
        public void WhenCompleteElCuadroDeTextoDelPasswordConElValor(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"hago click en el boton inicio de sesion")]
        public void WhenHagoClickEnElBotonInicioDeSesion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"complete el cuadro de texto con el codigo '(.*)'")]
        public void WhenCompleteElCuadroDeTextoConElCodigo(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"complete el cuadro de texto del password con el valor '(.*)'")]
        public void WhenCompleteElCuadroDeTextoDelPasswordConElValor(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el texto '(.*)' deberia de aparecer")]
        public void ThenElTextoDeberiaDeAparecer(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"deberia de ingresar correctamente a mi usuario")]
        public void ThenDeberiaDeIngresarCorrectamenteAMiUsuario()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
