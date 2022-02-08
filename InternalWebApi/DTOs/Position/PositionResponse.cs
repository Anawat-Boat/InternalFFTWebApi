namespace InternalWebApi.DTOs.Position
{
    public class PositionResponse
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public static PositionResponse FromPosition(Models.Position position)
        {
            return new PositionResponse
            {
                PositionId = position.PositionId,
                PositionName = position.PositionName
            };
        }
    }
}