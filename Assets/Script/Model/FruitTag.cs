public enum FruitTag {
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6,
}


public static class FruitTagExtensions {
    public static bool isMaximumLevel(this FruitTag tag) {
        return tag == FruitTag.Level6;
    }
}
