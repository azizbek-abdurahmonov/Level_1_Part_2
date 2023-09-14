using N38_Task1.Models;

namespace N38_Task1.Services.Interfaces;

public interface IMedicineService
{
    void Create(Medicine medicine);
    IEnumerable<Medicine> GetMedicines();
    Medicine GetById(Guid id);
    void Update(Medicine medicine);
    void Delete(Guid id);
    bool Sell(Guid id);
    bool Buy(Guid id);
}