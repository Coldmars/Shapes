SELECT 
    product."Name",
    category."Name"
FROM 
    Products product
LEFT JOIN 
    ProductCategories pc ON product.Id = pc.ProductId
LEFT JOIN 
    Categories category ON pc.CategoryId = category.CategoryId
ORDER BY 
    product."Name";