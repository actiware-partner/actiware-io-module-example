[ApiController]
[Route("api/v1/processor")]
public class MyProcessorController(IProcessorService service) : ProcessorController(service)
{
}