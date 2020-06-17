export interface IProduct {
  id: number;
  code: string;
  description: string;
  category: string;
  subCategory: string;
  categoryId: number;
  subCategoryId: number;
  price: number;
  status: boolean;
}
