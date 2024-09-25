using TestApp;

namespace TriangleTest;

public class Tests
{
    [Fact]
    public void CorrectPerimeterTest()
    {
        int[] sides = [8, 6, 10];
        
        var triangle = new Triangle(sides[0], sides[1], sides[2]);
        
        Assert.Equal(24, triangle.Perimeter);
    }

    [Fact]
    public void CorrectSquareFinding()
    {
        int[] sides = [8, 6, 10];
        
        var triangle = new Triangle(sides[0], sides[1], sides[2]);
        
        Assert.Equal(24, triangle.Square);
    }
}