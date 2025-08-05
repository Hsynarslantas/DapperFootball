namespace DapperSoccer.Dtos.PlayerDto
{
    public class TopPotentialPlayerDto
    {
        public int player_api_id { get; set; }
        public string player_name { get; set; }
        public byte? overall_rating { get; set; }
        public byte? potential { get; set; }
    }
}
