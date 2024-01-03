import IProductCard from "./IProductCard";

export default interface ICategoryCard {
  id: string;
  title:string;
  image: string;
  products: IProductCard[];
}
