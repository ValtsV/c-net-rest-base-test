using AsyncExamples;
using System.Diagnostics;


//sync
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine("\nBienvenido a la calculadora de Hipotecas Sincrona");

var anyosVidaLaboral = CalculadoraHipotecaSync.ObtenerAnyosVidaLaboral();
Console.WriteLine($"\nAnyos de vida laboral obtenidos: {anyosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo neto obtenido: {sueldoNeto}$");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensuales}");

var hipotecaConcedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(
    anyosVidaLaboral,
    esTipoContratoIndefinido,
    sueldoNeto,
    gastosMensuales,
    cantidadSolicitada: 50000,
    anyosPagar: 30);

var resultado = hipotecaConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnalisis Finalizado. Su solicitud de hipoteca ha sido: {resultado}");

stopwatch.Stop();

Console.WriteLine($"\nLa operacion ha durado: {stopwatch.Elapsed}");


// async
stopwatch.Restart();

Console.WriteLine("\nBienvenido a la calculadora de Hipotecas Sincrona");

Task<int> anyosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAnyosVidaLaboral();
Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinido();
Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();
Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();

var analisisHipotecaTasks = new List<Task>
{
    anyosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while (analisisHipotecaTasks.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTasks);

    if(tareaFinalizada == anyosVidaLaboralTask)
    {
        Console.WriteLine($"\nAnyos de vida laboral obtenidos: {anyosVidaLaboralTask.Result}");
    }
    else if (tareaFinalizada == esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }
    else if (tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {sueldoNetoTask.Result}$");
    }
    else if (tareaFinalizada == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensualesTask.Result}");
    }

    analisisHipotecaTasks.Remove(tareaFinalizada); 
}

var hipotecaConcedidaAsync = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(
    anyosVidaLaboralTask.Result,
    esTipoContratoIndefinidoTask.Result,
    sueldoNetoTask.Result,
    gastosMensualesTask.Result,
    cantidadSolicitada: 50000,
    anyosPagar: 30);

var resultadoAsync = hipotecaConcedidaAsync ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnalisis Finalizado. Su solicitud de hipoteca ha sido: {resultadoAsync}");

stopwatch.Stop();

Console.WriteLine($"\nLa operacion ha durado: {stopwatch.Elapsed}");