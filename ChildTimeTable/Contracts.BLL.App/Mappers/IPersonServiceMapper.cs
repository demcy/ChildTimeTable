using Contracts.BLL.Base.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPersonServiceMapper: IBaseMapper<DALAppDTO.Person, BLLAppDTO.Person>
    {
        //BLLAppDTO.PersonDisplay MapPersonDisplay(DALAppDTO.PersonDisplay inObject);
        BLLAppDTO.Person MapPersonDisplay(DALAppDTO.PersonDisplay inObject);
    }
}