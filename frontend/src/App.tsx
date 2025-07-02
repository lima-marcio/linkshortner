import { useState } from "react";
import axios from "axios";

function App() {
  const [originalUrl, setOriginalUrl] = useState("");
  const [shortUrl, setShortUrl] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");
    setShortUrl("");
    console.log(originalUrl);

    try {
      const response = await axios.post(
        "http://localhost:5214/api/linkshortner/shorten",
        { originalUrl },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      console.log(response.data);

      setShortUrl(response.data.shortUrl);
    } catch (err) {
      setError("Erro ao encurtar a URL.");
    }
  };

  return (
    <div style={{ padding: "2rem", maxWidth: 600, margin: "0 auto" }}>
      <h2>Encurtador de URL</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={originalUrl}
          onChange={(e) => setOriginalUrl(e.target.value)}
          placeholder="Cole sua URL aqui"
          style={{ width: "100%", padding: "0.5rem", marginBottom: "1rem" }}
        />
        <button type="submit" style={{ padding: "0.5rem 1rem" }}>
          Encurtar
        </button>
      </form>

      {shortUrl && (
        <div style={{ marginTop: "1rem" }}>
          <strong>URL Encurtada:</strong>{" "}
          <a href={shortUrl} target="_blank" rel="noopener noreferrer">
            {shortUrl}
          </a>
        </div>
      )}

      {error && <div style={{ color: "red", marginTop: "1rem" }}>{error}</div>}
    </div>
  );
}

export default App;
