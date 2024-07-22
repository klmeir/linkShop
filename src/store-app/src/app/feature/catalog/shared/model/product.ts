export interface Product {
  id: string;
  name: string;
  description: string;
  price: number;
  pictureFileName: string;
  productTypeId: string; // Assuming GUID as string for simplicity
  productType: ProductType;
  productBrandId: string; // Assuming GUID as string for simplicity
  productBrand: ProductBrand;
  availableStock: number;
}

interface ProductType {
  id: string;
  type: string;
}

interface ProductBrand {
  id: string;
  brand: string;
}
