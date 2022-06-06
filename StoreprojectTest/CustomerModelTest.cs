using StoreprojectModel;
using Xunit;

namespace StoreprojectTest;

public class CustomerModelTest
{


    [Fact]
    public void customerId_Should_Set_ValidData()
    {
        //Arrange
        Customer customerObj = new Customer();
        int customerId = 28;

        //Act
        customerObj.customerID = customerId;

        //Assert
        Assert.NotNull(customerObj.customerID);
        Assert.Equal(customerId, customerObj.customerID);
    }

    [Theory]
    [InlineData(-19)]
    [InlineData(-1290)]
    [InlineData(0)]
    [InlineData(-12983)]
    public void customerId_Should_Fail_Set_InvalidData(int p_customerId)
    {
        //Arrange
        Customer customerObj = new Customer();

        //Act & Assert
        Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
            {
                customerObj.customerID = p_customerId;
            }
        );

    }

    [Fact]
    public void Phone_Should_contain_digits()
    {
        // Arrange
        Customer CustomerObj = new Customer();
        double Phone = 1234567890;

        // Act
        CustomerObj.Phone = Phone;

        // Assert
        Assert.NotNull(CustomerObj.Phone);
        Assert.Equal(Phone, CustomerObj.Phone);
    }

    [Theory]
    [InlineData(123)]
    [InlineData(1627)]
    [InlineData(123445)]
    [InlineData(0)]
    public void Phone_should_Fail_Set_InvalidData(double p_phone)
    {

        // Arrange
        Customer CustomerObj = new Customer();


        // Act & Assert
        Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
        {
            CustomerObj.Phone = p_phone;
        }
         );

    }

    [Fact]
    public void Name_Should_contain_Letters_Only()
    {
        // Arrange
        Customer CustomerObj = new Customer();
        string Name =  "Joshua";

        // Act
        CustomerObj.Name = Name;

        // Assert
        Assert.NotNull(CustomerObj.Name);
        Assert.Equal(Name, CustomerObj.Name);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("!@#$")]
    [InlineData("%^&*")]
    [InlineData("-20=4+")]
    public void Name_should_Fail_Set_InvalidData(string n_name)
    {

        // Arrange
        Customer CustomerObj = new Customer();


        // Act & Assert
        Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
        {
            CustomerObj.Name = n_name;
        }
         );
    }

    [Fact]
    public void storeId_Should_Set_ValidData()
    {
        //Arrange
        Storefront storeObj = new Storefront();
        int storeID = 28;

        //Act
        storeObj.storeID = storeID;

        //Assert
        Assert.NotNull(storeObj.storeID);
        Assert.Equal(storeID, storeObj.storeID);
    }

    [Theory]
    [InlineData(-19)]
    [InlineData(-1290)]
    [InlineData(0)]
    [InlineData(-12983)]
    public void storeId_Should_Fail_Set_InvalidData(int p_storeID)
    {
        //Arrange
        Storefront storeObj = new Storefront();
        //Act & Assert
        Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
            {
                storeObj.storeID = p_storeID;
            }
        );

    }
}