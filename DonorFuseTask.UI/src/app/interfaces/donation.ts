export interface Donation {
  id: number;
  amount: number;
  date: string;
  donorId: number;
  scheduleId?: number | null;
}
