namespace DapperSoccer.Dtos.PlayerDto
{
    public class BestPotentialPlayerDto
    {
        public int player_api_id { get; set; }
        public string player_name { get; set; }
        public int potential { get; set; }
        public int finishing { get; set; }
        public int dribbling { get; set; }
        public int agility { get; set; }
        public int stamina { get; set; }
        public  int sprint_speed { get; set; }
        public int? overall_rating { get; set; }

    }
}
