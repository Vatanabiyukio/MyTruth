using WindOnDemilich;
namespace EarthOnDemilich;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public void test_1_10000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_10000_1000_1"),
                         563647);}

    [Test]
    public void test_1_1000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_1000_1000_1"),
                         54503);}

    [Test]
    public void test_1_100_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_100_1000_1"), 9147);}

    [Test]
    public void test_1_2000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_2000_1000_1"),
                         110625);}

    [Test]
    public void test_1_200_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_200_1000_1"), 11238);}

    [Test]
    public void test_1_5000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_5000_1000_1"),
                         276457);}

    [Test]
    public void test_1_500_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_1_500_1000_1"), 28857);}

    [Test]
    public void test_2_10000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_10000_1000_1"),
                         90204);}

    [Test]
    public void test_2_1000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_100_1000_1"), 1514);}

    [Test]
    public void test_2_100_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_1000_1000_1"), 9052);}

    [Test]
    public void test_2_2000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_2000_1000_1"),
                         18051);}

    [Test]
    public void test_2_200_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_200_1000_1"), 1634);}

    [Test]
    public void test_2_5000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_5000_1000_1"),
                         44356);}

    [Test]
    public void test_2_500_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_2_500_1000_1"), 4566);}

    [Test]
    public void test_3_10000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_10000_1000_1"),
                         146919);}

    [Test]
    public void test_3_1000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_1000_1000_1"),
                         14390);}

    [Test]
    public void test_3_100_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_100_1000_1"), 2397);}

    [Test]
    public void test_3_2000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_2000_1000_1"),
                         28919);}

    [Test]
    public void test_3_200_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_200_1000_1"), 2697);}

    [Test]
    public void test_3_5000_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_5000_1000_1"),
                         72505);}

    [Test]
    public void test_3_500_1000(){
        Assert.AreEqual(Projeto.MétodoDinâmico("/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_500_1000_1"), 7117);}
}