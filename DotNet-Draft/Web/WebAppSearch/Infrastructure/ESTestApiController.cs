﻿using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppSearch.Models;

namespace WebAppSearch.Infrastructure
{
    public class ElasticSearchHelper
    {
        public static readonly ElasticSearchHelper Intance = new ElasticSearchHelper();
        private ElasticConnection Client;

        private ElasticSearchHelper()
        {
            var node = new Uri("http://localhost:9200");

            Client = new ElasticConnection("localhost", 9200);
        }

        /// <summary>
        /// 数据索引
        /// </summary>
        /// <param name="indexName">索引名称</param>
        /// <param name="indexType">索引类型</param>
        /// <param name="id">索引文档id，不能重复,如果重复则覆盖原先的</param>
        /// <param name="jsonDocument">要索引的文档,json格式</param>
        /// <returns></returns>
        public IndexResult Index(string indexName, string indexType, string id, string jsonDocument)
        {
            var serializer = new JsonNetSerializer();
            string cmd = new IndexCommand(indexName, indexType, id);
            OperationResult result = Client.Put(cmd, jsonDocument);

            var indexResult = serializer.ToIndexResult(result.Result);
            return indexResult;
        }

        public IndexResult Index(string indexName, string indexType, string id, object document)
        {
            var serializer = new JsonNetSerializer();
            var jsonDocument = serializer.Serialize(document);
            return Index(indexName, indexType, id, jsonDocument);
        }

        //全文检索，单个字段或者多字段 或关系
        //字段intro 包含词组key中的任意一个单词
        //
        public personList Search<person>(string indexName, string indexType, string key, int from, int size)
        {
            string cmd = new SearchCommand(indexName, indexType);
            string query = new QueryBuilder<person>()
                //1 查询
                .Query(b =>
                    b.Bool(m =>
                            //并且关系
                            m.Must(t =>

                                        //分词的最小单位或关系查询
                                        t.QueryString(t1 => t1.DefaultField("intro").Query(key))
                            //.QueryString(t1 => t1.DefaultField("name").Query(key))
                            // t .Terms(t2=>t2.Field("intro").Values("研究","方鸿渐"))
                            //范围查询
                            // .Range(r =>  r.Field("age").From("100").To("200") )
                            )
                    )
                )
                //分页
                .From(from)
                .Size(size)
                //排序
                // .Sort(c => c.Field("age", SortDirection.desc))
                //添加高亮
                .Highlight(h => h
                    .PreTags("<b>")
                    .PostTags("</b>")
                    .Fields(
                        f => f.FieldName("intro").Order(HighlightOrder.score),
                        f => f.FieldName("_all")
                    )
                )
                .Build();

            string result = Client.Post(cmd, query);
            var serializer = new JsonNetSerializer();
            var list = serializer.ToSearchResult<Models.person>(result);
            personList datalist = new personList();
            datalist.hits = list.hits.total;
            datalist.took = list.took;
            var personList = list.hits.hits.Select(c => new Models.person()
            {
                id = c._source.id,
                age = c._source.age,
                birthday = c._source.birthday,
                intro = string.Join("", c.highlight["intro"]), //高亮显示的内容，一条记录中出现了几次
                name = c._source.name,
                sex = c._source.sex,
            });
            datalist.list.AddRange(personList);
            return datalist;
        }

        //全文检索，多字段 并关系
        //字段intro 或者name 包含词组key
        public personList SearchFullFileds<person>(string indexName, string indexType, string key, int from, int size)
        {
            MustQuery<person> mustNameQueryKeys = new MustQuery<person>();
            MustQuery<person> mustIntroQueryKeys = new MustQuery<person>();
            var arrKeys = GetIKTokenFromStr(key);
            foreach (var item in arrKeys)
            {
                mustNameQueryKeys = mustNameQueryKeys.Term(t3 => t3.Field("name").Value(item)) as MustQuery<person>;
                mustIntroQueryKeys = mustIntroQueryKeys.Term(t3 => t3.Field("intro").Value(item)) as MustQuery<person>;
            }

            string cmd = new SearchCommand(indexName, indexType);
            string query = new QueryBuilder<person>()
                //1 查询
                .Query(b =>
                            b.Bool(m =>
                                m.Should(t =>
                                         t.Bool(m1 =>
                                                     m1.Must(
                                                             t2 =>
                                                                 //t2.Term(t3=>t3.Field("name").Value("研究"))
                                                                 //   .Term(t3=>t3.Field("name").Value("方鸿渐"))
                                                                 mustNameQueryKeys
                                                             )
                                                )
                                       )
                               .Should(t =>
                                         t.Bool(m1 =>
                                                     m1.Must(t2 =>
                                                                     //t2.Term(t3 => t3.Field("intro").Value("研究"))
                                                                     //.Term(t3 => t3.Field("intro").Value("方鸿渐"))
                                                                     mustIntroQueryKeys
                                                            )
                                                )
                                      )
                                  )
                        )
                 //分页
                 .From(from)
                 .Size(size)
                  //排序
                  // .Sort(c => c.Field("age", SortDirection.desc))
                  //添加高亮
                  .Highlight(h => h
                      .PreTags("<b>")
                      .PostTags("</b>")
                      .Fields(
                             f => f.FieldName("intro").Order(HighlightOrder.score),
                              f => f.FieldName("name").Order(HighlightOrder.score)
                             )
                     )
                    .Build();

            string result = Client.Post(cmd, query);
            var serializer = new JsonNetSerializer();
            var list = serializer.ToSearchResult<Models.person>(result);
            personList datalist = new personList();
            datalist.hits = list.hits.total;
            datalist.took = list.took;
            var personList = list.hits.hits.Select(c => new Models.person()
            {
                id = c._source.id,
                age = c._source.age,
                birthday = c._source.birthday,
                intro = c.highlight == null || !c.highlight.Keys.Contains("intro") ? c._source.intro : string.Join("", c.highlight["intro"]), //高亮显示的内容，一条记录中出现了几次
                name = c.highlight == null || !c.highlight.Keys.Contains("name") ? c._source.name : string.Join("", c.highlight["name"]),
                sex = c._source.sex
            });
            datalist.list.AddRange(personList);
            return datalist;
        }

        //全文检索，多字段 并关系
        //搜索age在100到200之间，并且字段intro 或者name 包含词组key
        public personList SearchFullFiledss<person>(string indexName, string indexType, string key, int from, int size)
        {
            MustQuery<person> mustNameQueryKeys = new MustQuery<person>();
            MustQuery<person> mustIntroQueryKeys = new MustQuery<person>();
            var arrKeys = GetIKTokenFromStr(key);
            foreach (var item in arrKeys)
            {
                mustNameQueryKeys = mustNameQueryKeys.Term(t3 => t3.Field("name").Value(item)) as MustQuery<person>;
                mustIntroQueryKeys = mustIntroQueryKeys.Term(t3 => t3.Field("intro").Value(item)) as MustQuery<person>;
            }

            string cmd = new SearchCommand(indexName, indexType);
            string query = new QueryBuilder<person>()
                //1 查询
                .Query(b =>
                    b.Bool(m =>
                        m.Must(t =>
                            t.Range(r => r.Field("age").From("1").To("500"))
                                .Bool(ms =>
                                    ms.Should(ts =>
                                            ts.Bool(m1 =>
                                                m1.Must(
                                                    t2 =>
                                                            //t2.Term(t3=>t3.Field("name").Value("研究"))
                                                            //   .Term(t3=>t3.Field("name").Value("方鸿渐"))
                                                            //
                                                            mustNameQueryKeys
                                                )
                                            )
                                        )
                                        .Should(ts =>
                                            ts.Bool(m1 =>
                                                m1.Must(t2 =>
                                                        //t2.Term(t3 => t3.Field("intro").Value("研究"))
                                                        //.Term(t3 => t3.Field("intro").Value("方鸿渐"))

                                                        //
                                                        mustIntroQueryKeys
                                                )
                                            )
                                        )
                                )
                        )
                    )
                )
                //分页
                .From(from)
                .Size(size)
                //排序
                // .Sort(c => c.Field("age", SortDirection.desc))
                //添加高亮
                .Highlight(h => h
                    .PreTags("<b>")
                    .PostTags("</b>")
                    .Fields(
                        f => f.FieldName("intro").Order(HighlightOrder.score),
                        f => f.FieldName("name").Order(HighlightOrder.score)
                    )
                )
                .Build();

            string result = Client.Post(cmd, query);
            var serializer = new JsonNetSerializer();
            var list = serializer.ToSearchResult<Models.person>(result);
            personList datalist = new personList();
            datalist.hits = list.hits.total;
            datalist.took = list.took;
            var personList = list.hits.hits.Select(c => new Models.person()
            {
                id = c._source.id,
                age = c._source.age,
                birthday = c._source.birthday,
                intro = c.highlight == null || !c.highlight.Keys.Contains("intro") ? c._source.intro : string.Join("", c.highlight["intro"]), //高亮显示的内容，一条记录中出现了几次
                name = c.highlight == null || !c.highlight.Keys.Contains("name") ? c._source.name : string.Join("", c.highlight["name"]),
                sex = c._source.sex
            });
            datalist.list.AddRange(personList);
            return datalist;
        }

        //分词映射
        private static string BuildCompanyMapping()
        {
            return new MapBuilder<person>()
                .RootObject(typeName: "person",
                            map: r => r
                    .All(a => a.Enabled(false))
                    .Dynamic(false)
                    .Properties(pr => pr
                        .String(person => person.name, f => f.Analyzer(DefaultAnalyzers.standard).Boost(2))
                        .String(person => person.intro, f => f.Analyzer("ik_max_word"))
                        )
              )
              .BuildBeautified();
        }

        //将语句用ik分词，返回分词结果的集合
        private List<string> GetIKTokenFromStr(string key)
        {
            string s = "/db_test/_analyze?analyzer=ik_max_word";
            var result = Client.Post(s, "{" + key + "}");
            var serializer = new JsonNetSerializer();
            var list = serializer.Deserialize(result, typeof(ik)) as ik;
            return list.tokens.Select(c => c.token).ToList();
        }
    }
}