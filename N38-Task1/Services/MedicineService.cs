using N38_Task1.Models;
using N38_Task1.Services.Interfaces;

namespace N38_Task1.Services;

public class MedicineService : IMedicineService
{
    private List<Medicine> _medicines;

    public MedicineService()
    {
        _medicines = new List<Medicine>();
    }

    public void Create(Medicine medicine)
    {
        _medicines.Add(medicine);
    }

    public IEnumerable<Medicine> GetMedicines()
    {
        return _medicines;
    }

    public Medicine GetById(Guid id)
    {
        return _medicines.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Medicine medicine)
    {
        var foundedMedicine = _medicines.FirstOrDefault(x => x.Id == medicine.Id);
        if (foundedMedicine != null)
        {
            foundedMedicine.Name = medicine.Name;
            foundedMedicine.Price = medicine.Price;
            foundedMedicine.ExpirationDate = medicine.ExpirationDate;
            foundedMedicine.Count = medicine.Count;
            foundedMedicine.Description = medicine.Description;
            foundedMedicine.UpdatedAt = medicine.UpdatedAt;
        }
    }

    public void Delete(Guid id)
    {
        var medicine = _medicines.FirstOrDefault(x => x.Id == id);
        if (medicine != null)
        {
            _medicines.Remove(medicine);
        }
    }

    public bool Sell(Guid id)
    {
        var foundedMedicine = _medicines.FirstOrDefault(x => x.Id == id);
        if (foundedMedicine != null)
        {
            foundedMedicine.Count--;
            return true;
        }

        return false;
    }

    public bool Buy(Guid id)
    {
        var founded = _medicines.FirstOrDefault(x => x.Id == id);
        if (founded != null)
        {
            founded.Count++;
            return true;
        }

        return false;
        
    }
}