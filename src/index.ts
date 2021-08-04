import { Pool } from "pg";
export const db = new Pool({
  user: "spark",
  database: "spark",
  password: "mysparkpassword",
  host: "localhost",
  port: 5432,
  ssl: false,
});

async function connectToDB() {
  const res = await db.query("select * from users");
  console.log(res.rows);
  // process.exit(1);
}

async function main() {
  try {
    console.log("starting to tetrieve data ...");
    connectToDB();
  } catch (ex) {
    console.log(ex.message);
  }
}

main();
