using TouristApp.Persistance;

namespace TouristApp.Tests.Common;

public abstract class TestCommandBase : IDisposable {
    protected readonly TouristApplicationDbContext _context;

    public TestCommandBase() {
        _context = TouristApplicationContextFactory.CreateContext();
    }

    public void Dispose() {
        TouristApplicationContextFactory.Destroy(_context);
    }
}