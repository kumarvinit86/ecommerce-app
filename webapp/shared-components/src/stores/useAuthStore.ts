import { create } from "zustand";

interface AuthState {
  user: { username: string } | null;
  accessToken: string | null;
  refreshToken: string | null;
  setUser: (
    user: { username: string },
    accessToken: string,
    refreshToken: string
  ) => void;
}

export const useAuthStore = create<AuthState>((set) => ({
  user: null,
  accessToken: null,
  refreshToken: null,
  setUser: (user, accessToken, refreshToken) =>
    set({ user, accessToken, refreshToken }),
}));