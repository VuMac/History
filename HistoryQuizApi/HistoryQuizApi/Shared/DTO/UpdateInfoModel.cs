﻿namespace HistoryQuizApi.Shared.DTO
{
    public class UpdateInfoModel
    {
        public Guid id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Email { get; set; }
    }
}
