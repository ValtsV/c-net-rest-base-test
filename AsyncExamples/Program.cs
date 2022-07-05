using AsyncExamples;
using System.Diagnostics;

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
