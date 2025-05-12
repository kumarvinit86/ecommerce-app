// src/api/apiClient.ts
export async function apiClient<T = any>(
  url: string,
  options?: RequestInit
): Promise<T> {
  try {
    const response = await fetch(url, {
      headers: {
        "Content-Type": "application/json",
        ...(options?.headers || {})
      },
      ...options,
    });

    const data = await response.json();
    if (!response.ok) {
      throw new Error(data.message || "API Error");
    }
    return data;
  } catch (error) {
    console.error("API Error:", error);
    throw error;
  }
}
