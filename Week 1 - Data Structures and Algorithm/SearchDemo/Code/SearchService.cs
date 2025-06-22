using System;

namespace SearchDemo;

public static class SearchService
{
    /* ---------- LINEAR SEARCH: O(n) ---------- */
    public static Product? LinearSearchById(Product[] products, int targetId)
    {
        foreach (var p in products)
        {
            if (p.ProductId == targetId)
                return p;                   // found
        }
        return null;                        // not found
    }

    /* ---------- BINARY SEARCH: O(log n) ---------- */
    public static Product? BinarySearchById(Product[] sortedProducts, int targetId)
    {
        int lo = 0, hi = sortedProducts.Length - 1;

        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;  // avoid overflow
            int midId = sortedProducts[mid].ProductId;

            if (midId == targetId)
                return sortedProducts[mid];         // found
            if (midId < targetId)
                lo = mid + 1;                       // search right half
            else
                hi = mid - 1;                       // search left half
        }
        return null;                                // not found
    }
}
