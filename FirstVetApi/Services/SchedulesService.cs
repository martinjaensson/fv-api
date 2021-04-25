
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstVetApi.Clients;
using FirstVetApi.Dto;
using FirstVetApi.Models;
using FirstVetApi.Translators;
using Newtonsoft.Json;

namespace FirstVetApi.Services
{
    public class SchedulesService
    {
        private readonly FtpClient _ftpClient;
        // TODO: put in a config file
        private readonly string schedulesFilePath = @"C:\Kunduppdrag\FirstVet\FirstVetApi\FirstVetApi\Files\Example.json";
        public SchedulesService(FtpClient ftpClient)
        {
            _ftpClient = ftpClient;
        }

        public async Task<List<Schedule>> GetSchedules()
        {
            string jsonString = _ftpClient.Get(schedulesFilePath);
            List<ScheduleDto> scheduleDtos = JsonConvert.DeserializeObject<List<ScheduleDto>>(jsonString);
            return scheduleDtos.Select(ScheduleTranslator.ToModel).ToList();
        }
    }
}
