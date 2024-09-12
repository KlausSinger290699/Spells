namespace SCD.Spells.Unused.Other
{
    public enum ResourceType
    {
        Red = 0,
        Food = 1,
        Colonists = 2,
        Energy = 3,
        TiOre = 4,
        Gas = 5,
        Research = 6,
    }
    

    [System.Serializable]
    public struct ResourceAmount
    {
        public ResourceAmount(ResourceType type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }

        public ResourceType type;
        public int amount;

        public static ResourceAmount operator +(ResourceAmount a, ResourceAmount b)
        {
            return new ResourceAmount(a.type, a.amount + b.amount);
        }

        public static ResourceAmount operator -(ResourceAmount a, ResourceAmount b)
        {
            return new ResourceAmount(a.type, a.amount - b.amount);
        }

        public override string ToString()
        {
            return $"{type} {amount}";
        }

        public string ToPrettyString()
        {
            return $"Type: {type} Amount: {amount}";
        }

        public void ClearResource()
        {
            amount = 0;
        }
    }
}