namespace IChiba.Core.Domain
{
    public class IChibaListItem
    {
        public object Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        public bool Disabled { get; set; }
    }
}
