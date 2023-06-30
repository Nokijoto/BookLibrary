export interface NewBook {
  title: string;
  totalPages: number;
  rating: number;
  isbn?: string;
  publishedDate: Date;
  description?: string;
  imageUrl?: string;
}
